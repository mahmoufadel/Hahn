import { inject, NewInstance } from 'aurelia-framework';
import { IAsset } from '../Model/IAsset';
import { DialogService, DialogController } from 'aurelia-dialog';
import { ValidationController } from 'aurelia-validation';
import { DataService } from '../services/DataService'
import { Router, RouterConfiguration } from 'aurelia-router';
import { AssetDialog } from 'dialogs/asset-dialog';

@inject(DataService, Router, DialogController, NewInstance.of(ValidationController),
  DialogService)
export class Track {
  UserName: string
  added = new Set();
  removed=new Set();
  current=new Set();
  assets: Array<IAsset> = [];
  constructor(private userService: DataService, private router: Router,
    private dialogController, private validationController, private dialogService) {
    this.dialogController = dialogController;
    this.validationController = validationController;

  }
  async activate(params, routeConfig): Promise<void> {
    const response = await this.userService.get('Asset/GetAll');
    this.assets = await response.json();
    this.assets.filter(a => a.tracked).forEach(asset=> this.current.add(asset));
  }
  addAsset(id) {
    var asset=this.assets.find(a => a.id == id);
    asset.tracked=true;    
    this.added.add(asset);
    this.removed.delete(asset);
  }
  removeAsset(id) {
    var asset=this.assets.find(a => a.id == id); 
    asset.tracked=false;
    this.removed.add(asset);
    this.added.delete(asset);
  }

  trackAssets() {
    var userAssets = this.assets.filter(a => a.tracked);
    this.userService.post('User/TrackAssets', userAssets).then(Response => {
      this.router.navigate('profile');
    });

  }

 

  trackUserAssets() {
    this.dialogService.open({
      viewModel: AssetDialog
      , model: { assets :this.assets.filter(a => a.tracked) , current:this.current
      ,added :this.added,removed:this.removed} 
    })
      .then(result => {
        result.closeResult.then(res => {
          if (res.wasCancelled) return;
          this.trackAssets();
        }
        )

      });

  }
}
