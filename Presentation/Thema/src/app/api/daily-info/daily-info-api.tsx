import axios from "axios";
import { Retryer } from "react-query/types/core/retryer";
import { DailyInfoResponseModel } from "../../../models/daily-info/daily-info-response-model";
import ServiceResponse from "../../../models/service-response";


const API_URL = import.meta.env.VITE_APP_API_URL;
export function getDailyInfo() {
    var response = axios.post<ServiceResponse<DailyInfoResponseModel>>(API_URL + "/get-random-daily-info");
    return response;
}
