import { useState, useEffect } from 'react'
import { CarCard, NavBar, SearchBar, SideBar } from '../components'
import { type IBrand, type ICar } from '../interfaces'
import * as carsService from '../services/cars.service'
import * as brandsService from '../services/brands.service'
import { BsChevronRight, BsChevronLeft } from 'react-icons/bs'

export function Home() {
  const [cars, setCars] = useState<ICar[]>([])
  const [brands, setBrands] = useState<IBrand[]>([])
  const [currentPage, setCurrentPage] = useState<number>(1)
  const [totalPages, setTotalPages] = useState<number>(1)
  const [selectedBrand, setSelectedBrand] = useState('')

  const onSearch = (search: string) => {
    void carsService.getAllCars({ name: search }).then((response) => {
      setCars(response.cars)
    })
  }

  const goPreviousPage = () => {
    if (currentPage > 1) {
      void carsService
        .getAllCars({ page: currentPage - 1 })
        .then((response) => {
          setCars(response.cars)
          setCurrentPage(response.currentPage)
          setTotalPages(response.totalPages)
        })

      window.scrollTo(0, 0)
    }
  }

  const goNextPage = () => {
    if (currentPage < totalPages) {
      void carsService
        .getAllCars({ page: currentPage + 1 })
        .then((response) => {
          setCars(response.cars)
          setCurrentPage(response.currentPage)
          setTotalPages(response.totalPages)
        })

      window.scrollTo(0, 0)
    }
  }

  useEffect(() => {
    void carsService.getAllCars().then((response) => {
      setCars(response.cars)
      setCurrentPage(response.currentPage)
      setTotalPages(response.totalPages)
    })

    void brandsService.getAllBrands().then((response) => {
      setBrands(response)
    })
  }, [])

  useEffect(() => {
    if (selectedBrand !== '') {
      void carsService
        .getAllCars({ brandName: selectedBrand })
        .then((response) => {
          setCars(response.cars)
          setCurrentPage(response.currentPage)
          setTotalPages(response.totalPages)
        })
    } else {
      void carsService.getAllCars().then((response) => {
        setCars(response.cars)
        setCurrentPage(response.currentPage)
        setTotalPages(response.totalPages)
      })
    }
  }, [selectedBrand])

  return (
    <div>
      <NavBar />
      <SearchBar onSearch={onSearch} />
      <main className='flex max-w-7xl m-auto mt-6'>
        <SideBar
          brands={brands}
          selectedBrand={selectedBrand}
          setSelectedBrand={setSelectedBrand}
        />

        <section>
          <section className='grid grid-cols-2 md:grid-cols-3 mb-8'>
            {cars.length > 0 &&
              cars.map((car) => <CarCard key={car.carId} car={car} />)}
          </section>

          <div className='w-full flex mb-12'>
            <section className='m-auto flex items-center text-lg'>
              <button
                onClick={goPreviousPage}
                className='p-3 bg-gray-800 rounded-md mx-3'
              >
                <BsChevronLeft className='text-white' />
              </button>

              <p>{`${currentPage} de ${totalPages}`}</p>

              <button
                onClick={goNextPage}
                className='p-3 bg-gray-800 rounded-md mx-3'
              >
                <BsChevronRight className='text-white' />
              </button>
            </section>
          </div>
        </section>
      </main>
    </div>
  )
}
