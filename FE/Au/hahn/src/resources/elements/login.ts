//import {computedFrom} from 'aurelia-framework';
import { inject } from 'aurelia-framework';
import { DataService } from '../services/DataService'
import { Router, RouterConfiguration } from 'aurelia-router';
import {I18N} from 'aurelia-i18n';


import { AuthService } from 'aurelia-auth';

@inject(AuthService,I18N)

export class Login {
  constructor(private auth: AuthService,private i18n:I18N) {
    this.auth = auth;
    console.log(this.i18n.tr('friend'));
  };

  heading = 'Login';
  userName: string = 'fadel';
  password: string = 'Otv@123';
  submit() {

    return this.auth.login(this.userName, this.password)
      .then(response => {
        console.log("success logged :: " + this.auth.isAuthenticated());        
      })
      .catch(err => {
        console.log("login failure");
      });
  };

  authenticate(name) {
    return this.auth.authenticate(name, true, null)
      .then((response) => {
        console.log("auth response " + response);
      });
  }
}


