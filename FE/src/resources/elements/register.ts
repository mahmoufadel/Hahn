import { AuthService } from 'aurelia-auth';
import { inject, NewInstance } from 'aurelia-framework';
import { ValidationController } from 'aurelia-validation';
import { RegisterModel } from 'resources/Model/RegisterModel';
import { DataService } from 'resources/services/DataService';
import { ValidationRules } from 'aurelia-validation';
import {DisabledIfNotValid} from '../attributes/disabledIfNotValid'

@inject(AuthService, DataService, NewInstance.of(ValidationController))

export class Register {
  isFormChanged=true;
  heading = 'Sign Up';
  userInfo: RegisterModel;
  signupError = '';
  loginForm: any;
  constructor(private auth: AuthService, private userService: DataService, private validationController) {
    this.userInfo = new RegisterModel();
    this.addValidation() ;
  };

  signup() {
;
    this.validationController.validate().then(errors => {
      
      var t=this.validationController.errors.length;
      if (errors.valid) { 
              
        return this.userService.post('Authenticate/register', this.userInfo)
            .then((response) => {
              console.log("Signed Up!");
            })
            .catch(error => {
              this.signupError = error.response;
            });
      }
    });
  }
  change()
  {
    this.isFormChanged=this.isFormChanged?false:true;

  }
  addValidation() 
  {
    ValidationRules
    .ensure((o: RegisterModel) => o.FirstName).required().withMessage('plz add First name ')
    .ensure((o: RegisterModel) => o.LastName).required()
    .ensure((o: RegisterModel) => o.Email).required().email()
    .ensure((o: RegisterModel) => o.Age).required().min(18).max(99)
    .ensure((o: RegisterModel) => o.Username).required().maxLength(20).minLength(5)
    .ensure((o: RegisterModel) => o.Password).required().minLength(6).matches(/^[a-zA-Z0-9]{6,16}$/)
  
    
    
    .on(this.userInfo);
  }
  IsValidForm()
  {

    return this.validationController.validate();
  }
  clear() {
    this.userInfo = new RegisterModel();
    this.validationController.reset();
    this.addValidation() ;
    this.signupError = '';
    this.isFormChanged=true;
  }
}

