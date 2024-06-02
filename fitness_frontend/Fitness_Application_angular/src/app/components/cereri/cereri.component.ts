import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Route, Router } from '@angular/router';
import { CreazaCereriComponent } from '../creaza-cereri/creaza-cereri.component';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-cereri',
  standalone: true,
  imports: [FormsModule,MatFormFieldModule,MatInputModule,MatSelectModule,MatOptionModule,HttpClientModule,ReactiveFormsModule],
  templateUrl: './cereri.component.html',
  styleUrl: './cereri.component.css'
})
export class CereriComponent implements OnInit {

  raspunsForm!:FormGroup;

  user:any=[];
  JSONUser:any=[];

  userbyId:any=[];
  cereri:any=[];

  private readonly apiUrlUser="https://localhost:7270/api/User/";
  private readonly apiUrlCereri="https://localhost:7270/api/Cereri/";

  constructor(private dialog: MatDialog,private http:HttpClient,private router:Router){}
  ngOnInit(): void {

    this.JSONUser=localStorage.getItem("utilizatorId");
    this.user=JSON.parse(this.JSONUser);
    this.http.get(`${this.apiUrlUser}GetUserById?id=${this.user[0].Id}`).subscribe(data=>{
      this.userbyId=data;
      console.log(this.userbyId[0].Admin);
    });
    this.loadCereri();
    this.raspunsForm=new FormGroup({
    raspuns:new FormControl(''),
    verdict: new FormControl('')
    });
    
  }

  loadCereri(){
    this.http.get(`${this.apiUrlCereri}GetCereri`).subscribe(data=>{
      this.cereri=data;
    })
  }

  OnRaspunsCerere(Id:any){
    this.raspunsCerere(Id,this.raspunsForm.value.raspuns).subscribe(res=>{
      if(this.raspunsForm.value.verdict == "Aprobata"){
        this.acceptaCerere(Id).subscribe(data=>{

        });
        alert("Cerere aprobata cu succes");
        this.loadCereri();
      }
      else if(this.raspunsForm.value.verdict == "Respinsa"){
        this.respingeCerere(Id).subscribe(data=>{

        });
        alert("Cerere respinsa cu succes");
        this.loadCereri();
      }
    })
  }

  OnStergeCererea(Id:any){
this.stergeCererea(Id).subscribe(data=>{
  alert("Cererea ta fost stearsa cu succes");
  this.loadCereri();
})
  }

  stergeCererea(Id:any){
    return this.http.delete(`${this.apiUrlCereri}DeleteCerere?Id=${Id}`);
  }

  raspunsCerere(Id:any,raspuns:any){
return this.http.patch(`${this.apiUrlCereri}RaspunsCerere?Id=${Id}&raspuns=${raspuns}`,null);
  }
  acceptaCerere(Id:any){
    return this.http.patch(`${this.apiUrlCereri}StatusAcceptat?Id=${Id}`,null);
  }
  respingeCerere(Id:any){
    return this.http.patch(`${this.apiUrlCereri}StatusRespins?Id=${Id}`,null);
  }

  onCreazaCerere(){

    this.dialog.open(CreazaCereriComponent);
  }

}
