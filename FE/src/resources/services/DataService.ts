import { inject } from 'aurelia-framework';
import { json } from 'aurelia-fetch-client';
import { CustomHttpClient } from 'customHttp';

@inject(CustomHttpClient)
export class DataService {

  constructor(private httpClient: CustomHttpClient) {
   
  }
  get(fn) {
    
    return this.httpClient.fetch(fn);
  }
  post(fn, body) {
    return this.httpClient.fetch(fn, {
      method: 'post',
      body: json(body)
    });
  }
}

export class BearerAuthorizationInterceptor {
  constructor(private token) {
    this.token = token;
  }

  request(request) {
    request.headers.set('Authorization', `Bearer ${this.token}`);
  }
}



