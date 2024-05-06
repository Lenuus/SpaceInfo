import { FC } from 'react'
import { useIntl } from 'react-intl'
import { toAbsoluteUrl } from '../../../_metronic/helpers'
import { PageTitle } from '../../../_metronic/layout/core'
import {
  ListsWidget2,
  ListsWidget3,
  ListsWidget4,
  ListsWidget6,
  TablesWidget5,
  TablesWidget10,
  MixedWidget8,
  CardsWidget7,
  CardsWidget17,
  CardsWidget20,
  ListsWidget26,
  EngageWidget10,
} from '../../../_metronic/partials/widgets'
import { Content } from '../../../_metronic/layout/components/content'
import { auto } from '@popperjs/core'

const DashboardPage: FC = () => (
  <>
    <div style={{ marginBottom: auto }}>
      <div id="kt_carousel_3_carousel" className="carousel carousel-custom slide mx-auto" style={{ maxHeight: "300px" }} data-bs-ride="carousel" data-bs-interval="8000">
        <div className="d-flex align-items-center justify-content-between flex-wrap">
          <span className="fs-4 fw-bold pe-2">Title</span>
          <ol className="p-0 m-0 carousel-indicators carousel-indicators-bullet carousel-indicators-active-primary">
            <li data-bs-target="#kt_carousel_3_carousel" data-bs-slide-to="0" className="ms-1 active"></li>
            <li data-bs-target="#kt_carousel_3_carousel" data-bs-slide-to="1" className="ms-1"></li>
            <li data-bs-target="#kt_carousel_3_carousel" data-bs-slide-to="2" className="ms-1"></li>
          </ol>
        </div>
        <div className="carousel-inner pt-8">
          <div className="carousel-item active">
            <div className="bgi-no-repeat rounded mb-6" style={{ backgroundImage: `url(https://picsum.photos/1450/300)`, backgroundSize: "cover", height: "300px", width: auto, marginLeft: "auto", marginRight: "auto" }}></div>
          </div>

          <div className="carousel-item">
            <div className="bgi-no-repeat rounded mb-6" style={{ backgroundImage: `url(https://picsum.photos/1450/300)`, backgroundSize: "cover", height: "300px", width: auto, marginLeft: "auto", marginRight: "auto" }}></div>
          </div>

          <div className="carousel-item">
            <div className="bgi-no-repeat rounded mb-6" style={{ backgroundImage: `url(https://picsum.photos/1450/300)`, backgroundSize: "cover", height: "300px", width: auto, marginLeft: "auto", marginRight: "auto" }}></div>
          </div>
        </div>
      </div>
    </div>
    <div className="mt-4">
      <div className="card bg-light shadow-sm">
        <div className="card-header">
          <h3 className="card-title">Title</h3>
          <div className="card-toolbar">
            <button type="button" className="btn btn-sm btn-light">
              Action
            </button>
          </div>
        </div>
        <div className="card-body card-scroll h-200px">
          Lorem Ipsum is simply dummy text...
        </div>
        <div className="card-footer">
          Footer
        </div>
      </div>
    </div>
  </>
)

const DashboardWrapper: FC = () => {
  const intl = useIntl()
  return (
    <>
      <PageTitle breadcrumbs={[]}>{intl.formatMessage({ id: 'MENU.DASHBOARD' })}</PageTitle>
      <DashboardPage />
    </>
  )
}

export { DashboardWrapper }
