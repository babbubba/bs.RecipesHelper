import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class IngredientsService {

  baseUrl = '';

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getIngredientsInfo() {
    return this
      .http
      .get(this.baseUrl + 'api/ingredients/getingredientsinfo', {
        params: {
          enabledOnly: 'true'
        }
      });
  }

  findIngredientsInfo(enabledOnly, ingredientNamePattern) {
    return this
      .http
      .get(this.baseUrl + 'api/ingredients/getingredientsinfo', {
        params: {
          ingredientNamePattern: ingredientNamePattern,
          enabledOnly: enabledOnly
        }
      });
  }

  

  getIngredientsDetail() {
    return this
      .http
      .get(this.baseUrl + 'api/ingredients/getingredientsdetail');
  }

  createIngredient(name, isEnabled) {
    const ingredient = {
      name,
      isEnabled
    };
    return this
      .http.post(this.baseUrl + 'api/ingredients/createIngredient', ingredient);
  }

  //addProduct(ProductName, ProductDescription, ProductPrice) {
  //  const obj = {
  //    ProductName,
  //    ProductDescription,
  //    ProductPrice
  //  };
  //  console.log(obj);
  //  this.http.post(`${this.uri}/add`, obj)
  //    .subscribe(res => console.log('Done'));
  //}
}
