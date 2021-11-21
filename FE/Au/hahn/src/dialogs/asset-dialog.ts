import {inject, NewInstance} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';
import {ValidationController} from 'aurelia-validation';

@inject(DialogController, NewInstance.of(ValidationController))
export class AssetDialog {
  model;
  activeTabId;
  myTabs;
  assets;old;added;removed;
  constructor(private dialogController,private validationController) {
    this.dialogController = dialogController;
    this.validationController = validationController;
    this.activeTabId = 'all';
  this.myTabs = [
    { id: 'all', label: 'All' , active: true},
    { id: 'added', label: 'Added Assets' },
    { id: 'removed', label: 'Removed Assets' },
    { id: 'old', label: 'old' },
    
  ];
  }

  activate(model) {
    this.model = model;
    this.assets=model.assets;
    this.added=Array.from(model.added.values());
    this.removed=Array.from(model.removed.values());
    this.old=Array.from(model.current.values());
    this.activeTabId = 'all';
    console.log(this.added,this.removed)
  }

  ok() {
    
    this.validationController.validate().then(errors => {
      if (errors.valid) {
        this.dialogController.ok(this.model.assets)
      }
    });
  }

  cancel() {
    this.dialogController.cancel();
  }
}
