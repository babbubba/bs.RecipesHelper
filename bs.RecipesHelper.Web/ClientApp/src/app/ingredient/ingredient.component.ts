import { Component, OnInit, Input } from '@angular/core';
import { IngredientInfo } from '../../../Models/Ingredient.model';

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.css']
})
export class IngredientComponent implements OnInit {

  @Input() ingredientInfo: IngredientInfo;

  constructor() { }

  ngOnInit() {
  }

}
