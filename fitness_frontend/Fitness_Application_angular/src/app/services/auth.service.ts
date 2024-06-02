import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  
  constructor(private http: HttpClient) { }
  readonly APIUrl = "https://localhost:7270/api/User/";
  /*
  idJSON:any=[];

  isLoggedIn(){
    this.idJSON=localStorage.getItem("utilizatorId");

    if(this.idJSON.Activ){
      return true;
    }
    return false;
  }
  isAdmin(){
    this.idJSON=localStorage.getItem("utilizatorId");

    if(this.idJSON.Admin){
      return true;
    }
    return false;
  }

/*signup(userObj:any){
  return this.http.post(`${this.APIUrl}signup`,userObj);
}

login(userObj:any){
  return this.http.post(`${this.APIUrl}login`,userObj);
}*/


}
