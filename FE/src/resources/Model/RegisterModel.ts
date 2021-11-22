import { Address } from "./IUser";
export class RegisterModel {
    constructor()
    {
        this.Address=new  Address()
    }
    Username: string;
    FirstName: string;
    LastName: string;
    Age: string;
    Address: Address;
    Email: string[];
    Password: string;
  }
