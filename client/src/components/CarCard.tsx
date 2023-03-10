import { type ICar } from '../interfaces'

interface IProps {
  car: ICar
}

export function CarCard({ car }: IProps) {
  return (
    <div className='max-w-sm rounded overflow-hidden shadow-md m-auto'>
      <img className='w-full' src={car.imageUrl} alt={car.name} />
      <div className='px-6 py-4'>
        <div className='font-bold text-xl mb-2'>{car.name}</div>
        <p className='text-gray-700 text-base'>{`${car.brandName} - ${car.model} - Ano ${car.year}`}</p>
      </div>
      <div className='px-6 pt-4 pb-2'>
        <span className='inline-block px-3 py-1 text-sm font-semibold text-gray-700 mr-2 mb-2'>
          {car.price}
        </span>
      </div>
    </div>
  )
}
