import { type ICar } from '../interfaces'
import { formatPrice } from '../utils'

interface IProps {
  car: ICar
}

export function CarCard({ car }: IProps) {
  return (
    <div className='w-full p-4'>
      <div className='h-full bg-white rounded-lg shadow-md hover:shadow-lg hover:cursor-pointer'>
        <img
          className='w-full object-cover h-48 rounded-t-lg'
          src={car.imageUrl}
          alt={car.name}
        />
        <div className='p-4'>
          <div className='font-bold text-xl mb-2'>{car.name}</div>
          <p className='text-gray-700 text-base'>{`${car.brandName} - ${car.model} - Ano ${car.year}`}</p>
          <div className='mt-4'>
            <span className='inline-block text-2xl text-blue-600 mr-2 mb-2'>
              {formatPrice(car.price)}
            </span>
          </div>
        </div>
      </div>
    </div>
  )
}
