import { IAsset } from "./IAsset";

export interface IUser {
    avatar_url: string;
    firstName: string;
    lastName: string;
    age: string;
    address: Address;
    assets: IAsset[];
  }
export  class Address {    
    houseNumber: string;
    street: string;
    postalCode: string;
  }

  