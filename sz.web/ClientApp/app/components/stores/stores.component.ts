import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Article } from './models/article.model';
import { Store } from './models/store.model';
import { StoreService }  from './services/store.service';

@Component({
    selector: 'stores',
    templateUrl: './stores.component.html',
    styleUrls: ['./stores.component.css'],
    providers: [ StoreService ]
})
export class StoresComponent {
    public stores: Store[];
    public articles: Article[];
    public selectedStore: Store;

    constructor(private _service: StoreService) {
        this._service.getStores().subscribe(result => {
            this.stores = result.json().stores as Store[];
            if (this.stores) {
                this.selectedStore = this.stores[0];
                this.onSelect(this.stores[0]);
            }
        });
    }    

    onSelect(store: Store) {
        this.selectedStore = store;
        this._service.getProductsByStore(store).subscribe(result => {                
            this.articles = this.convertToArticle(result.json());
        });
        console.log(store);
    }

    convertToArticle(res) {
        let body = res.articles;
        let result: Article[] = [];
        if (body instanceof Array) {
            for (let i = 0; i < body.length; i++) {
                let article: Article = {
                    id: body[i].id || 0,
                    name: body[i].name || "",
                    description: body[i].description || "",
                    price: body[i].price,
                    total_in_shelf: body[i].total_in_shelf || 0,
                    total_in_vault: body[i].total_in_vault || 0,
                    store_name: body[i].store_name || ""
                };
                result.push(article);
            }
        }
        return result;
    }
}
