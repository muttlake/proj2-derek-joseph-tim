import {Injectable } from "@angular/core";
import { Observable } from 'rxjs/Observable';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { catchError, retry } from 'rxjs/operators';
import { HttpClient  } from "@angular/common/http";
import { HttpHeaders } from '@angular/common/http';
import { User } from '../register/user';


@Injectable()
 

export class UserService{
client:HttpClient;
httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
      
    })
  };

    constructor( client: HttpClient){
        this.client = client;
    }
 
    create(user: User): Observable<any>  {
        return this.client.post('http://52.15.149.129/datasvc/api/user', user, this.httpOptions);
        // .pipe(
        //     catchError(this.handleError('addUser', user))
        //   );
    }



}

