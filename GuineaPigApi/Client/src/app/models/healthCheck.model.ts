export interface HealthCheckModel {
  id: number;
  guineaPigId: number;
  isPawsCheck: boolean;
  pawsComment: string;
  isChinCheck: boolean;
  chinComment: string;
  isMouthCheck: boolean;
  mouthComment: string;
  isNoseCheck: boolean;
  noseComment: string;
  isTeethCheck: boolean;
  teethComment: string;
  isEyesCheck: boolean;
  eyesComment: string;
  isEarsCheck: boolean;
  earsComment: string;
  isFurCheck: boolean;
  furComment: string;
  weight: number;
  healthCheckDate: Date;
}
