import { FC } from 'react'
import { useIntl } from 'react-intl'
import { toAbsoluteUrl } from '../../../_metronic/helpers'
import { PageTitle } from '../../../_metronic/layout/core'
import { auto } from '@popperjs/core'

const DashboardPage: FC = () => (
  <>
    <div style={{ marginBottom: "80px",  }}>
      <div id="kt_carousel_3_carousel" className="carousel carousel-custom slide mx-auto" style={{ maxHeight: "300px"  }} data-bs-ride="carousel" data-bs-interval="8000">
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
    <div className="mt-4 d-flex justify-content-between">
      <div className="card bg-light shadow-sm me-2" style={{ width: "calc(50% - 0.5rem)" }}>
        <div className="card-header">
          <h3 className="card-title">Title</h3>
          <div className="card-toolbar">
            <button type="button" className="btn btn-sm btn-light">
              About
            </button>
          </div>
        </div>
        <div className="card-body card-scroll h-200px">
          "Space" is the term used to describe the vast expanse beyond Earth's atmosphere, encompassing all matter, energy, time, and space itself. It is believed to be the infinite extent in which stars, galaxies, planets, and other celestial bodies exist. According to the Big Bang theory, the universe began approximately 13.8 billion years ago, and since then, it has been expanding. Space is a fundamental concept studied in fields such as astronomy, physics, and cosmology.
        </div>
      </div>
      <div className="card bg-light shadow-sm" style={{ width: "calc(50% - 0.5rem)"}}>
        <div className="card-header">
          <h3 className="card-title">Title</h3>
          <div className="card-toolbar">
            <button type="button" className="btn btn-sm btn-light">
              About
            </button>
          </div>
        </div>
        <div className="card-body card-scroll h-200px">
          "Space" is the term used to describe the vast expanse beyond Earth's atmosphere, encompassing all matter, energy, time, and space itself. It is believed to be the infinite extent in which stars, galaxies, planets, and other celestial bodies exist. According to the Big Bang theory, the universe began approximately 13.8 billion years ago, and since then, it has been expanding. Space is a fundamental concept studied in fields such as astronomy, physics, and cosmology.
        </div>
      </div>
    </div>
    <div className="mt-2 d-flex justify-content-between">
      <div className="card bg-light shadow-sm me-2" style={{ width: "calc(50% - 0.5rem)" }}>
        <div className="card-header">
          <h3 className="card-title">Title</h3>
          <div className="card-toolbar">
            <button type="button" className="btn btn-sm btn-light">
              About
            </button>
          </div>
        </div>
        <div className="card-body card-scroll h-200px">
          "Space" is the term used to describe the vast expanse beyond Earth's atmosphere, encompassing all matter, energy, time, and space itself. It is believed to be the infinite extent in which stars, galaxies, planets, and other celestial bodies exist. According to the Big Bang theory, the universe began approximately 13.8 billion years ago, and since then, it has been expanding. Space is a fundamental concept studied in fields such as astronomy, physics, and cosmology.
        </div>
      </div>
      <div className="card bg-light shadow-sm" style={{ width: "calc(50% - 0.5rem)" }}>
        <div className="card-header">
          <h3 className="card-title">Title</h3>
          <div className="card-toolbar">
            <button type="button" className="btn btn-sm btn-light">
              About
            </button>
          </div>
        </div>
        <div className="card-body card-scroll h-200px">
          "Space" is the term used to describe the vast expanse beyond Earth's atmosphere, encompassing all matter, energy, time, and space itself. It is believed to be the infinite extent in which stars, galaxies, planets, and other celestial bodies exist. According to the Big Bang theory, the universe began approximately 13.8 billion years ago, and since then, it has been expanding. Space is a fundamental concept studied in fields such as astronomy, physics, and cosmology.
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
