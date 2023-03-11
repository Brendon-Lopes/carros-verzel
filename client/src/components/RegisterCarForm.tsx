import { useEffect, useState } from 'react'
import { useForm } from 'react-hook-form'
import { type IBrand } from '../interfaces'
import * as brandService from '../services/brands.service'
import * as carService from '../services/cars.service'
import { useCookies } from 'react-cookie'
import { useNavigate, useLocation } from 'react-router-dom'
import {
  createCarResolver,
  type ICreateCarFormData,
} from '../validations/create-car.validation'

export function RegisterCarForm() {
  const location = useLocation()
  const { state } = location
  const editMode = state.editMode as boolean

  const [brands, setBrands] = useState<IBrand[]>([])

  const [cookies] = useCookies(['token'])

  const navigate = useNavigate()

  const formMethods = useForm<ICreateCarFormData>({
    resolver: createCarResolver,
  })

  const {
    formState: { errors },
    register,
    handleSubmit,
    setValue,
  } = formMethods

  const onSubmit = (data: ICreateCarFormData) => {
    const token = cookies.token

    void carService.createCar(data, token).then((res) => {
      if (res === false) {
        alert('Erro ao cadastrar!')
        return
      }

      alert('Carro cadastrado com sucesso!')
      navigate('/')
    })
  }

  const onEdit = (data: ICreateCarFormData) => {
    console.log('edit')
    const token = cookies.token

    void carService.editCar(state.car!.carId, data, token).then((res) => {
      if (res === false) {
        alert('Erro ao editar!')
        return
      }

      alert('Carro editado com sucesso!')
      navigate('/')
    })
  }

  useEffect(() => {
    void brandService.getAllBrands().then((res) => {
      setBrands(res)
    })

    setValue('name', editMode ? state.car.name : '')
    setValue('model', editMode ? state.car.model : '')
    setValue('year', editMode ? state.car.year : 0)
    setValue('price', editMode ? state.car.price : 0)
    setValue('imageUrl', editMode ? state.car.imageUrl : '')
    setValue('brand', editMode ? state.car.brandName : '')
  }, [editMode])

  return (
    <form
      onSubmit={handleSubmit(editMode ? onEdit : onSubmit)}
      className='w-full sm:w-full md:w-3/4 lg:w-1/2 m-auto mt-6'
    >
      <div className='mb-6'>
        <label
          htmlFor='name'
          className='block mb-2 text-sm font-medium text-gray-900'
        >
          Nome / Descrição
        </label>
        <input
          type='text'
          {...register('name')}
          className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
        />
        {errors.name !== undefined && (
          <p className='error-message'>{errors.name.message}</p>
        )}
      </div>

      <div className='mb-6'>
        <label
          htmlFor='model'
          className='block mb-2 text-sm font-medium text-gray-900'
        >
          Modelo
        </label>
        <input
          type='text'
          {...register('model')}
          className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
        />
        {errors.model !== undefined && (
          <p className='error-message'>{errors.model.message}</p>
        )}
      </div>

      {!editMode && (
        <div className='mb-6'>
          <label
            htmlFor='brand'
            className='block mb-2 text-sm font-medium text-gray-900 dark:text-white'
          >
            Marca
          </label>
          <select
            {...register('brand')}
            defaultValue=''
            className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
          >
            <option disabled value=''>
              Selecione uma marca
            </option>
            {brands.map((brand) => (
              <option key={brand.brandId} value={brand.brandId}>
                {brand.name}
              </option>
            ))}
          </select>
          {errors.brand !== undefined && (
            <p className='error-message'>{errors.brand.message}</p>
          )}
        </div>
      )}

      <div className='mb-6'>
        <label
          htmlFor='year'
          className='block mb-2 text-sm font-medium text-gray-900'
        >
          Ano
        </label>
        <input
          type='number'
          {...register('year')}
          className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
        />
        {errors.year !== undefined && (
          <p className='error-message'>{errors.year.message}</p>
        )}
      </div>

      <div className='mb-6'>
        <label
          htmlFor='price'
          className='block mb-2 text-sm font-medium text-gray-900'
        >
          Preço
        </label>
        <input
          type='number'
          {...register('price')}
          className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
        />
        {errors.price !== undefined && (
          <p className='error-message'>{errors.price.message}</p>
        )}
      </div>

      <div className='mb-6'>
        <label
          htmlFor='imageUrl'
          className='block mb-2 text-sm font-medium text-gray-900'
        >
          URL da imagem
        </label>
        <input
          type='text'
          {...register('imageUrl')}
          className='bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5'
        />
        {errors.imageUrl !== undefined && (
          <p className='error-message'>{errors.imageUrl.message}</p>
        )}
      </div>

      <button
        type='submit'
        className='text-white bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center'
      >
        {editMode ? 'Editar' : 'Cadastrar'}
      </button>
    </form>
  )
}
