import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
      PalestrantesComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,//TODO- BroserAnimationsModule - não consegui importar essa biblioteca se der probelma ver o video 200 minuto 8:00
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
