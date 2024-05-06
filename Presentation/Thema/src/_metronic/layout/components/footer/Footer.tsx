import { useEffect } from 'react'
import { ILayout, useLayout } from '../../core'
import { toAbsoluteUrl } from '../../../helpers'
import { left } from '@popperjs/core'

const Footer = () => {
  const { config } = useLayout()
  useEffect(() => {
    updateDOM(config)
  }, [config])
  return (
    <>
      <div className='text-gray-900 order-2 position-start' style={{ display: 'flex', justifyContent: 'flex-start' }}>
        <a href="https://www.nasa.gov/" target="_blank" rel="noopener noreferrer">any
          <span style={{ marginRight: '10px' }}>Click and go Nasa Page for more information</span>
          <img
            alt='Logo'
            src={toAbsoluteUrl('media/svg/food-icons/coffee.svg')}
            className='h-20px h-lg-30px app-sidebar-logo-default theme-dark-show'
          />
        </a>
      </div>
    </>
  )

}

const updateDOM = (config: ILayout) => {
  if (config.app?.footer?.fixed?.desktop) {
    document.body.classList.add('data-kt-app-footer-fixed', 'true')
  }

  if (config.app?.footer?.fixed?.mobile) {
    document.body.classList.add('data-kt-app-footer-fixed-mobile', 'true')
  }
}

export { Footer }
