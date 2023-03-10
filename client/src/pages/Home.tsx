import { useState, useEffect } from 'react'
import { CarCard, NavBar, SearchBar } from '../components'
import { type ICar } from '../interfaces'
import * as carsService from '../services/cars.service'

export function Home() {
  const [cars, setCars] = useState<ICar[]>([])

  useEffect(() => {
    void carsService.getAllCars().then((response) => {
      setCars(response.cars)
    })
  }, [])

  return (
    <div>
      <NavBar />
      <SearchBar />

      <main className='max-w-7xl m-auto grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4'>
        {cars.length > 0 &&
          cars.map((car) => <CarCard key={car.carId} car={car} />)}
      </main>
    </div>
  )
}
