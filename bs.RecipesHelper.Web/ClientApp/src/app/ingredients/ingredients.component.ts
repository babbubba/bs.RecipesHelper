import { Component, OnInit } from '@angular/core';
import { IngredientsService } from '../ingredients.service';
import { IngredientInfo } from '../../../Models/Ingredient.model';

@Component({
  selector: 'app-ingredients',
  templateUrl: './ingredients.component.html',
  styleUrls: ['./ingredients.component.css']
})
export class IngredientsComponent implements OnInit {

  ingredients: IngredientInfo[];

  constructor(private is: IngredientsService) { }


  ngOnInit() {
    this.is
      .getIngredientsInfo()
      .subscribe((data: IngredientInfo[]) => {
        this.ingredients = data;
      });
  }

  addIngredient() {
    this.is
      .createIngredient("Cipolla", true)
      .subscribe((data: string) => {
        console.log('Done! New id:' + data);
      });
  }

}
