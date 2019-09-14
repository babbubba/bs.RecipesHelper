import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IngredientDetailComponent } from './ingredient-detail/ingredient-detail.component';
import { IngredientComponent } from './ingredient/ingredient.component';
import { IngredientsComponent } from './ingredients/ingredients.component';
import { IngredientsService } from './ingredients.service';

@NgModule({
  declarations: [
    AppComponent,
    IngredientDetailComponent,
    IngredientComponent,
    IngredientsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [IngredientsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
