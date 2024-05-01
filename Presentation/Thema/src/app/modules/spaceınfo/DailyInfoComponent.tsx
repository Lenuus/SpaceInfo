import React, { FC } from 'react';
import { DailyInfoResponseModel } from '../../../models/daily-info/daily-info-response-model';
import { WithChildren } from '../../../_metronic/helpers';

type Props = {
    dailyinfo?: DailyInfoResponseModel
}

const DailyInfoComponent: FC<Props & WithChildren> = ({ dailyinfo }) => {
    return (
        <>
            <div className="card mb-5 mb-xl-8">
                <div className="card-body pb-0">
                    <div className="d-flex align-items-center mb-5">
                        <div className="d-flex align-items-center flex-grow-1">
                            <div className="d-flex flex-column">
                                <a href="#" className="text-gray-900 text-hover-primary fs-6 fw-bold">{dailyinfo?.date.toString()}</a>
                                <span className="text-gray-500 fw-bold">{dailyinfo?.title}</span>
                            </div>
                        </div>
                    </div>
                    <div className="mb-5">
                        <div className="bgi-no-repeat rounded mb-6" style={{ backgroundImage: `url(${dailyinfo?.hdurl})`, backgroundSize: "cover", height: "700px" }}></div>
                        <div className="text-gray-2000 mb-5">{dailyinfo?.explanation}</div>
                        <div className="text-gray-2000 position-absolute bottom-0 end-0">{dailyinfo?.copyright ? dailyinfo.copyright : "CopyRight"} </div>
                    </div>
                </div>
            </div>
        </>
    )
}
export default DailyInfoComponent;
