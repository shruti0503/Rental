import React from 'react'

const Logo = () => {
  return (
    <div className='flex  text-black flex-col'>
        <div className='w-5 h-1 bg-black'></div>
        <div className='flex justify-center items-center gap-1'>
        <div className='w-1 h-5 bg-black relative bottom-2'></div>
        <div className="text-3xl font-bold">
            Dwello   
        </div>
        <div className='w-[2px] h-4 relative top-2 bg-black'></div>
        </div>
        <div className='flex w-100 justify-end'> <div className='w-4 h-[2px] bg-black'></div></div>
    </div>
  )
}

export default Logo