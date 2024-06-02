import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoggedOutService {
  idJSON:any=[];
  id:any=[];
  constructor(private router: Router) { }

  isLoggedOut(){
    this.idJSON=localStorage.getItem("utilizatorId");
    this.id=JSON.parse(this.idJSON);
    
    if(this.id[0].Id > 0){
      return false;
    }
    return true;
  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    if(this.isLoggedOut())
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
