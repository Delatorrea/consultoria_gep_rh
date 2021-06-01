import { Component, OnInit } from '@angular/core';
import {AppService} from './app.service';
import { FormGroup, FormControl,Validators } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ProEventos-App';

  public eventos: any = [];
  EventoForm!: FormGroup;
  submitted = false;
  EventValue = "Salvar";

  constructor(private AppService: AppService) {
  }

  ngOnInit(): void {
     this.EventoForm = new FormGroup({
      eventoId: new FormControl(null),
      tema: new FormControl("",[Validators.required]),
      local: new FormControl("",[Validators.required]),
      dataEvento:new FormControl("",[Validators.required]),
      qtdPessoas: new FormControl("",[Validators.required]),
      lote: new FormControl("",[Validators.required]),
    })
    this.getAll();
  }

  public getAll(): void {
    this.AppService.getEventos().subscribe(
      response => {
        this.eventos = response;
      },
      error => console.log(error)
    )
    this.eventos;
  }

  public delete(evento: {
    eventoId: any; tema: any; local: any; dataEvento: any; qtdPessoas: any; lote: any;
  }) {
    this.AppService.deleteEvento(evento.eventoId).subscribe(
      response => {
        this.resetFrom();
        this.getAll();
    },
      error => console.log(error)
    )
  }

  public save() {
    try{

      this.submitted = true;
      if (this.EventoForm.invalid) {
        return console.log ('Evento form inválido');
      }
      this.EventoForm.removeControl('eventoId');

      this.AppService.postEvento(this.EventoForm.value).subscribe(
        response => {
          this.resetFrom();
      },
        error => console.log(error)
      )

    }catch (e){
      console.log(e)
    }
  }

  public update() {
    this.submitted = true;
    if (this.EventoForm.invalid) {
     return console.log ('Evento form inválido');
    }
    this.AppService.putEvento(this.EventoForm.value.eventoId, this.EventoForm.value).subscribe(
      response => {
        this.resetFrom();
    },
      error => console.log(error)
    )
  }

  public edit(Data: {
    eventoId: any; tema: any; local: any; dataEvento: any; qtdPessoas: any; lote: any;
  }){
    this.EventoForm.controls["eventoId"].setValue(Data.eventoId);
    this.EventoForm.controls["tema"].setValue(Data.tema);
    this.EventoForm.controls["local"].setValue(Data.local);
    this.EventoForm.controls["dataEvento"].setValue(Data.dataEvento);
    this.EventoForm.controls["qtdPessoas"].setValue(Data.qtdPessoas);
    this.EventoForm.controls["lote"].setValue(Data.lote);
    this.EventValue = "Atualizar";
  }

  public resetFrom() {
    this.getAll();
    this.EventoForm.reset();
    this.EventValue = "Salvar";
    this.submitted = false;
  }

  persisteDado() {
    if(this.EventValue==='Salvar'){
      return this.save();
    }
    return this.update();
  }
}


