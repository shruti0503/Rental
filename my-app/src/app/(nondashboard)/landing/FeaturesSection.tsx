"use client"
import React from 'react'
import {motion, stagger} from "framer-motion"
import Image from 'next/image'
import Link from 'next/link'

const containerVariants={
    hiddem:{opacity:0, y:50},
    visible:{
        opacity:1,
        y:0,
        transition:{
            duration:0.5,
            staggerChildren:0.2
        }
    }
}
const itemVariants={
    hidden:{opacity:0, y:20},
    visible:{opacity:1, y:0}
}

const FeaturesSection=()=>{

    return(
        <motion.div 
          initial="hidden"
          whileInView="visible"
          viewport={{once:true}}
          variants={containerVariants}
          className="py-24 px-6 sm:px-8 lg:px-12 xl:px-16 bg-white"
        >
            <div className="max-w-4xl xl:max-w-6xl mx-auto">
                <motion.h2>
                  Quickly find the home you want using our effective search filters!
                </motion.h2>
            </div>


        </motion.div>
    )
}

export default FeaturesSection