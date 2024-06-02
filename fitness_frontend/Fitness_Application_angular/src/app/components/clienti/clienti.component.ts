import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { forkJoin } from 'rxjs';

@Component({
  selector: 'app-clienti',
  standalone: true,
  imports: [MatCardModule,MatButtonModule],
  templateUrl: './clienti.component.html',
  styleUrl: './clienti.component.css'
})
export class ClientiComponent implements OnInit {
  
  constructor(private http:HttpClient){

  }

  readonly APIUrl = "https://localhost:7270/api/User/";
  clienti:any=[];
  utilizatorJSON!:any;
  utilizator!:any;

  ngOnInit(): void {
    this.utilizatorJSON=localStorage.getItem("utilizatorId");
    this.utilizator=JSON.parse(this.utilizatorJSON);
    forkJoin([this.http.get(`${this.APIUrl}GetClienti?id=${this.utilizator[0].Id}`)]).subscribe(([clienti])=>{
      this.clienti=clienti;
    })
    
  }

  stergeClient(user:any){
    return this.http.patch(`${this.APIUrl}StergeAntrenor`,user);
  }
  
  onStergeClient(user:any){
    this.stergeClient(user).subscribe(()=>{
      alert("Client sters cu succes");
      this.onLoadClienti();
    })
  }

  onLoadClienti(){
    this.http.get(`${this.APIUrl}GetClienti?id=${this.utilizator[0].Id}`).subscribe(data=>{
      this.clienti=data;
    })
  }

}
