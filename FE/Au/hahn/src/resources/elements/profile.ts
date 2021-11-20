import {inject} from 'aurelia-framework';
import { IAsset } from '../Model/IAsset';
import { IUser } from '../Model/IUser';
import {DataService} from '../services/DataService'

@inject(DataService) 
export class Profile {
  UserName:string
  User:IUser
  assets: Array<IAsset> = [];
  constructor(private userService: DataService) {}
  async activate(params,routeConfig): Promise<void> {     
  
       
    const response = await this.userService.get('User/Get');
    this.User = await response.json();   
    this.assets=this.User.assets;
    
  }
}


