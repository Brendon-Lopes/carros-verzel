import { type ICar } from './ICar.interface'

export interface ICarApiResponse {
  cars: ICar[]
  currentPage: number
  totalPages: number
}
