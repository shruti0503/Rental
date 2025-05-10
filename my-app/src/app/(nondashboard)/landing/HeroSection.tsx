"use client";

import Image from "next/image";
import React, { useState } from "react";
import { motion } from "framer-motion";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";



const HeroSection = () => {
   


 

  return (
    <div className="relative bg-[#EADDCA] h-screen">
      <Image
        src="/rent.jpg"
        alt="Rentiful Rental Platform Hero Section"
        fill
        className="object-cover object-center"
        priority
      />
      <div className="absolute inset-0 bg-opacity-60"></div>
      <motion.div
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.8 }}
        className="absolute top-1/3 transform -translate-x-1/2 -translate-y-1/2 text-center w-full"
      >
        <div className="max-w-4xl bg-opacity-40 bg-white p-10 rounded-lg mx-auto px-16 sm:px-12">
          <h1 className="text-5xl font-bold text-black mb-4">
            Find Your Dream Home
          </h1>
          <p className="text-xl text-black mb-8">
              Explore our curated selection of exquisite properties meticulously tailored to your unique dream home vision
          </p>

          <div className="flex justify-center">
            <Input
              type="text"
             // value={searchQuery}
              //onChange={(e) => setSearchQuery(e.target.value)}
              placeholder="Search by city, neighborhood or address"
              className="w-full max-w-lg rounded-none rounded-l-xl border-none bg-white h-12"
            />
            <Button
              //onClick={handleLocationSearch}
              className="bg-black text-white rounded-none rounded-r-xl border-none hover:bg-secondary-600 h-12"
            >
              Search
            </Button>
          </div>
        </div>
      </motion.div>
    </div>
  );
};

export default HeroSection;