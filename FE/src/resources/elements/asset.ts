import {bindable} from 'aurelia-framework';

export class Asset {
  @bindable assets;
  hasAssets=false;  
  constructor() {
    console.log(this.assets);
    this.hasAssets=this.assets.Length!=0;
  }
}
