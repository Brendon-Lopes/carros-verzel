import { type ICar } from '../interfaces'

interface IProps {
  car: ICar
}

export function CarCard({ car }: IProps) {
  return (
    <main className=''>
      <img src={car.imageUrl} alt={car.name} />
      <h1>{car.name}</h1>
      <p>{car.brandName}</p>
      <p>{car.model}</p>
      <p>{car.year}</p>
      <h3>{car.price}</h3>
    </main>
  )
}
