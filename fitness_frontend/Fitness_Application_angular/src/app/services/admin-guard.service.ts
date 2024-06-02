import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot,  GuardResult, MaybeAsync, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuardService {
  idJSON:any=[];
  id:any=[];
  constructor(private router: Router) { }

  isLoggedIn(){
    this.idJSON=localStorage.getItem("utilizatorId");
    this.id=JSON.parse(this.idJSON);
    if(this.id[0].Activ){
      return true;
    }
    return false;
  }
  isAdmin(){
    this.idJSON=localStorage.getItem("utilizatorId");
    this.id=JSON.parse(this.idJSON);
    if(this.id[0].Admin){
      return true;
    }
    return false;
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    if(this.isAdmin())
      {
        console.log("CE AI BA");
        return true;
      }
      else{
        console.log("CE AI BA2");
        return false;
      }
  }
   
}
