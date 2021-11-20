import {inject} from 'aurelia-framework';
import { IAsset } from '../Model/IAsset';
import { IUser } from '../Model/IUser';
import {DataService} from '../services/DataService'
import { Router, RouterConfiguration } from 'aurelia-router';

@inject(DataService,Router) 
export class Track {
  UserName:string
  
  assets: Array<IAsset> = [];
  constructor(private userService: DataService,private router:Router) {}
  async activate(params,routeConfig): Promise<void> {     
  
       
    const response = await this.userService.get('Asset/GetAll');
    this.assets = await response.json();   
   console.log(this.assets) 
    
  }
  addAsset(id)
  {
    this.assets.find(a=>a.id==id).tracked=true;
  }
  removeAsset(id)
  {
    this.assets.find(a=>a.id==id).tracked=false;
  }

  trackAssets()
  {
    var userAssets=this.assets.filter(a=>a.tracked);
    this.userService.post('User/TrackAssets',userAssets).then(Response=>{
      this.router.navigate('profile');
    });
    
  }

}
