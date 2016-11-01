#load "packages/MathNet.Numerics.FSharp/MathNet.Numerics.fsx"

open MathNet.Numerics.LinearAlgebra

type ImageData = Matrix<float>

let getRandomImageData () =
  DenseMatrix.randomStandard<float> 5 3073

let getRandomLabelsVector () =
  DenseVector.randomStandard<float> 5

let getRandomWeights () =
  DenseMatrix.randomStandard<float> 3073 1