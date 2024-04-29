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
                        <div className="my-0">
                            <button type="button" className="btn btn-sm btn-icon btn-color-primary btn-active-light-primary" data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end">
                                <i className="ki-duotone ki-category fs-6">
                                    <span className="path1"></span>
                                    <span className="path2"></span>
                                    <span className="path3"></span>
                                    <span className="path4"></span>
                                </i>
                            </button>
                            <div className="menu menu-sub menu-sub-dropdown menu-column menu-rounded menu-gray-800 menu-state-bg-light-primary fw-semibold w-200px" data-kt-menu="true">
                                <div className="menu-item px-3">
                                    <div className="menu-content fs-6 text-gray-900 fw-bold px-3 py-4">Quick Actions</div>
                                </div>
                                <div className="separator mb-3 opacity-75"></div>
                                <div className="menu-item px-3">
                                    <a href="#" className="menu-link px-3">New Ticket</a>
                                </div>
                                <div className="menu-item px-3">
                                    <a href="#" className="menu-link px-3">New Customer</a>
                                </div>
                                <div className="menu-item px-3" data-kt-menu-trigger="hover" data-kt-menu-placement="right-start">
                                    <a href="#" className="menu-link px-3">
                                        <span className="menu-title">New Group</span>
                                        <span className="menu-arrow"></span>
                                    </a>

                                    <div className="menu-sub menu-sub-dropdown w-175px py-4">
                                        <div className="menu-item px-3">
                                            <a href="#" className="menu-link px-3">Admin Group</a>
                                        </div>

                                        <div className="menu-item px-3">
                                            <a href="#" className="menu-link px-3">Staff Group</a>
                                        </div>

                                        <div className="menu-item px-3">
                                            <a href="#" className="menu-link px-3">Member Group</a>
                                        </div>
                                    </div>
                                </div>

                                <div className="menu-item px-3">
                                    <a href="#" className="menu-link px-3">New Contact</a>
                                </div>

                                <div className="separator mt-3 opacity-75"></div>

                                <div className="menu-item px-3">
                                    <div className="menu-content px-3 py-3">
                                        <a className="btn btn-primary btn-sm px-4" href="#">Generate Reports</a>
                                    </div>
                                </div>
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
