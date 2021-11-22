import { AuthService } from 'aurelia-auth';
import {inject} from 'aurelia-framework';

@inject(AuthService)
export class Logout {
 
  constructor(private authService:AuthService)
  {}
  
  async activate(): Promise<void> {         
    this.authService.logout('/')    
  }
}


