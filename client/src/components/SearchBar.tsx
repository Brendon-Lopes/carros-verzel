import { BsSearch } from 'react-icons/bs'

export function SearchBar() {
  return (
    <div className='bg-blue-600 h-16 flex justify-center items-center'>
      <div className='relative max-w-7xl h-4/6 w-full flex items-center'>
        <input
          className='rounded-sm p-2 w-full h-full'
          type='text'
          placeholder='Buscar por marca ou modelo...'
        />
        <BsSearch className='absolute right-2 text-xl text-gray-600' />
      </div>
    </div>
  )
}
