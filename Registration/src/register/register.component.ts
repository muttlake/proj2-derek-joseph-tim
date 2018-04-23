import { Component } from '@angular/core';
import { User } from './user';
import { UserService } from "../api/userservice";
import {NgForm} from '@angular/forms';

@Component({
    selector: 'reg',
    templateUrl: 'reg.component.html',
    styleUrls: ['reg.component.css']
})

export class RegisterComponent{

//user:User;
submitted = false;
client: UserService;
user = new User();
constructor(client: UserService){
    
    this.client = client;
  };

  onSubmit(f: NgForm) { 
      this.submitted = true;
      this.client.create(this.user).subscribe((err)=>console.log(err));
    //   document.location.href = '18.188.13.94/WeatherApp';
    document.location.href = 'http://18.188.13.94/WeatherApp';
 }
}


