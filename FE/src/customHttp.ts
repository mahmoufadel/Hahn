import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import 'isomorphic-fetch'; // if you need a fetch polyfill
import { AuthService } from 'aurelia-auth';
import * as environment from '../config/environment.json';

@inject(AuthService)
export class CustomHttpClient extends HttpClient {
    constructor(auth) {
        super();
       
        this.configure(config => {
            config
                .withBaseUrl(environment.apiUrl)
                .withDefaults({
                    credentials: 'same-origin',
                    headers: {
                        'Accept': 'application/json',
                        'X-Requested-With': 'Fetch'
                    }
                })
                
                .withInterceptor(auth.tokenInterceptor)               
                .withInterceptor({
                    request(request) {
                        console.log(`Requesting ${request.method} ${request.url}`);
                        return request; // you can return a modified Request, or you can short-circuit the request by returning a Response
                    },
                    response(response) {
                        console.log(`Received ${response.status} ${response.url}`);
                        return response; // you can return a modified Response
                    }
                });
        });
    }
}
