import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatOptionModule } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';

@Component({
  selector: 'app-generate-exercitiu',
  standalone: true,
  imports: [FormsModule,MatFormFieldModule,MatInputModule,MatSelectModule,MatOptionModule,HttpClientModule,ReactiveFormsModule],
  templateUrl: './generate-exercitiu.component.html',
  styleUrl: './generate-exercitiu.component.css'
})
export class GenerateExercitiuComponent implements OnInit {
  constructor(private http:HttpClient,private dialog: MatDialog,private router:Router){}

  exercitiuForm!:FormGroup;
  private readonly APIurl  = "https://localhost:7270/api/Exercitiu/";

  ngOnInit(): void {
    this.exercitiuForm = new FormGroup({
      Id: new FormControl(''),
      Nume: new FormControl(''),
      Descriere:new FormControl(''),
      Categorie:new FormControl(''),
      caloriiPer10Minute: new FormControl(''),
      caloriiPerRepetare: new FormControl(''),
      imagine: new FormControl(''),
      selectat:new FormControl('')
    });
  }

  add(exercitiu:any){
    return this.http.post(`${this.APIurl}AdaugaExercitiu`,exercitiu);
  }

  onAdd(){
    this.exercitiuForm.value.imagine=null;
    this.exercitiuForm.value.Id=0;
    this.exercitiuForm.value.selectat=0;
    this.add(this.exercitiuForm.value).subscribe({
      next:(res)=>{
        
        alert("Exercitiu adaugat cu succes");
        window.location.reload();
        this.onClose(); 
      },
      error:(err)=>{
        console.log(this.exercitiuForm.value)
        alert("Exercitiu nu a fost adaugat")
      }
    });
  }

  onClose(){
    this.dialog.closeAll();
  }

}
