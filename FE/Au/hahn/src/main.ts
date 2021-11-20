import {Aurelia} from 'aurelia-framework';
import environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';
import config from '../config/authConfig';
import { BootstrapFormValidationRenderer } from 'BootstrapFormValidationRenderer';
import {I18N, TCustomAttribute} from 'aurelia-i18n';
import Backend from 'i18next-xhr-backend';


export function configure(aurelia: Aurelia): void {
  aurelia.use
    .standardConfiguration()
    .developmentLogging()
    
    //.plugin(PLATFORM.moduleName('aurelia-form'))
    
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .plugin(PLATFORM.moduleName('aurelia-auth/auth-filter'))
    .plugin(PLATFORM.moduleName('aurelia-auth'), (baseConfig)=>{
         baseConfig.configure(config);
    })
    .plugin(PLATFORM.moduleName('aurelia-i18n'), (instance) => {
      let aliases = ['t', 'i18n'];
 
      TCustomAttribute.configureAliases(aliases);
      instance.i18next.use(Backend);
      //instance.i18next.use(Backend.with(aurelia.loader));

      return instance.setup({
              backend: {                                 
                loadPath: './locales/{{lng}}/{{ns}}.json',
              },
              attributes: aliases,
              lng : 'en',
              fallbackLng : 'es',
              whitelist: ['en', 'es',  'arab'],
              preload: ['en', 'es', 'arab'],
              debug : false
            });
    })
    
    .feature(PLATFORM.moduleName('resources/index'))
    
    
    ;
   
    aurelia.container.registerHandler('bootstrap-form', container => container.get(BootstrapFormValidationRenderer));
  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}


