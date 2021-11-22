
import {customAttribute, inject} from 'aurelia-framework'
import {ValidationController} from 'aurelia-validation'
import $ from 'jquery';
import { RegisterModel } from 'resources/Model/RegisterModel';


@inject(Element)
@customAttribute('disabled-if-not-valid')
export class DisabledIfNotValid {
    private element: $;
    private controller: ValidationController;

    constructor(element: Element) {
        this.element = $(element);
        this.element.prop('disabled', true);        
    }

    valueChanged() {
        
        let errorCount = this.controller.errors.length;
        if (errorCount === 0) {
            this.controller.validate();
        }
        this.element.prop('disabled', errorCount !== 0);
    }

    bind(bindingContext:{validationController:ValidationController}) {
        this.controller = bindingContext.validationController;
    }
}

@inject(Element)
@customAttribute('disabled-if-empty')
export class DisabledIfEmpty {
    private element: $;
    private elements;

    constructor(element: any) {
        this.elements= element.form.elements
        this.element = $(element);
       
        this.element.prop('disabled', true);        
    }

    valueChanged() {       
        let disabled=true;
        for (var i=0;i<this.elements.length;i++)
        {
            if(this.elements[i].value!='') 
            {disabled=false;  break;}
        }
        this.element.prop('disabled',disabled);
    }
    bind(bindingContext:{userInfo:RegisterModel}) {
        
    }
    
}

