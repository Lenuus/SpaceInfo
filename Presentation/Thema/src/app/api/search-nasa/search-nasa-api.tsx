import axios from "axios";
import { NasaSearchRequestModel } from "../../../models/nasa-search/nasa-search-request-model";
import { PagedResponseModel } from "../../../models/paged-response-model";
import ServiceResponse from "../../../models/service-response";
import { SearchItemResponseDataModel } from "../../../models/nasa-search/search-item-data-response-model";
import { NasaImageResponseModel } from "../../../models/nasa-search/nasa-image-response-model";


const API_URL = import.meta.env.VITE_APP_API_URL;
export function getSearchItems(request: NasaSearchRequestModel) {
    var response = axios.post<ServiceResponse<PagedResponseModel<SearchItemResponseDataModel>>>(API_URL + "/search-nasa-item", request);
    return response;
}
export function getSearchedItemsImage(request: string) {
    var response = axios.post<ServiceResponse<NasaImageResponseModel>>(API_URL + "/get-nasa-item-images", request);
    return response;
}
