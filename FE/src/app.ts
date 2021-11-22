import { Aurelia } from 'aurelia-framework';
import { Router, RouterConfiguration } from 'aurelia-router';
import { PLATFORM } from 'aurelia-pal';
import { inject } from 'aurelia-framework';
import { AuthorizeStep, AuthService, FetchConfig } from 'aurelia-auth';
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import 'font-awesome/css/font-awesome.min.css';

import '../static/styles.css';


@inject(Router, FetchConfig, RouterConfiguration)
export class App {
  router: Router;

  constructor(router, private fetchConfig, private routerConfiguration) {
    this.router = router;
    this.fetchConfig = fetchConfig;
  }

  activate() {
    this.fetchConfig.configure();

  }
  
  configureRouter(config: RouterConfiguration, router: Router) {
    config.title = 'Hahn';
    config.addPipelineStep('authorize', AuthorizeStep);
    config.map([
      { route: ['', 'welcome'], name: 'welcome', moduleId: PLATFORM.moduleName('./resources/elements/welcome'), nav: true, title: 'welcome', auth: false },
      { route: 'register', name: 'register', moduleId: PLATFORM.moduleName('./resources/elements/register'), nav: true, title: 'Register', auth: false },
     
     

      { route: 'profile', name: 'profile', moduleId: PLATFORM.moduleName('./resources/elements/profile'), nav: true, title: 'Profile', auth: true },
      { route: 'track', name: 'track', moduleId: PLATFORM.moduleName('./resources/elements/track'), nav: true, title: 'Track Your Assets', auth: true },
      
      { route: 'logout', name: 'logout', moduleId: PLATFORM.moduleName('./resources/elements/logout'), nav: true, title: 'Logout', auth: true },
      { route: 'login', name: 'login', moduleId: PLATFORM.moduleName('./resources/elements/login'), nav: true, title: 'Login', auth: false },


    ]);

    this.router = router;
  }

 
}
