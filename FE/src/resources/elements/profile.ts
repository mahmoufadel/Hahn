import {inject} from 'aurelia-framework';
import { IAsset } from '../Model/IAsset';
import { IUser } from '../Model/IUser';
import {DataService} from '../services/DataService'
import {I18N} from 'aurelia-i18n';

@inject(DataService) 
export class Profile {
  UserName:string
  User:IUser
  assets: Array<IAsset> = [];
  constructor(private userService: DataService,private i18N:I18N ) {}
  async activate(params,routeConfig): Promise<void> {     
  
       
    const response = await this.userService.get('User/Get');
    this.User = await response.json();   
    this.assets=this.User.assets;
    
  }
}


