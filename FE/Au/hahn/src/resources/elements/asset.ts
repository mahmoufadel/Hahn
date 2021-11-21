import {bindable} from 'aurelia-framework';

export class Asset {
  @bindable assets;  
  constructor() {
    console.log(this.assets);

  }
}
