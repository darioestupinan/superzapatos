import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'stores',
    templateUrl: './stores.component.html'
})
export class StoresComponent {
    public stores: Store[];
    public articles: Article[];

    constructor(private _http: Http) {        
        _http.get('http://localhost:62115/services/stores').subscribe(result => {
            this.stores = result.json().stores as Store[];
            if (this.stores) {
                this.onSelect(this.stores[0]);
            }
        });
    }    

    onSelect(store: Store) {

        this._http.get(`http://localhost:62115/services/articles/store/${store.id}`)
            .subscribe(result => {
                this.articles = result.json().articles as Article[];
        });
        console.log(store);
    }
}

interface Store {
    id: string;
    name: string;
    address: string;
}

interface Article {
    id: string;
    name: string;
    description: string;
    price: number;
    totalInShelf: number;
    totalInVault: number;
    storeId: number;
}
