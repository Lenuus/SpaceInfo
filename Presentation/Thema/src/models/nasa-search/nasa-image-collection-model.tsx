import { string } from "yup";
import { SearchItemResponseDataModel } from "./search-item-data-response-model";

class NasaSearchImageCollectionModel {

    public version: string = "";
    public href: string = "";
    public items: SearchItemResponseDataModel[] = []
}

export { NasaSearchImageCollectionModel }