using System;

namespace InitiationCSharp
{
    class Tableaux
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Combien de questions d�sirez-vous ?");
            int nbTotalQuestion = getNumberPositif(Console.ReadLine()); // On lit le nombre total de question


            int numQuestion = 1; // num�ro de question en cours
            //int nbTotalQuestion = 5; // nombre total de question
            int nbBonnesReponses = 0; // nombre de bonnes r�ponses

            while (numQuestion < nbTotalQuestion+1) // Tant qu'il reste des questions
            {
                Console.WriteLine("Question n�" + numQuestion + "/" + nbTotalQuestion + "\n");
                numQuestion = numQuestion + 1;

                Random rand = new Random(); // creation du random entre 1 et 2 pour savoir si c'est une addition (1) ou une multiplication (2)

                const int min = 1;
                const int max = 2;

                int TYPE_QUESTION = rand.Next(min, max + 1);

                int nombre = TYPE_QUESTION + 1;

                if (TYPE_QUESTION == 1) // Si c'est une addition
                {
                    Random rand2 = new Random(); // On cr�� les randoms des valeurs des calculs

                    const int min2 = 1;
                    const int max2 = 10;

                    int val1 = rand.Next(min2, max2 + 1); 

                    int nombre1 = val1 + 1;

                    int val2 = rand.Next(min2, max2 + 1);

                    int nombre2 = val2 + 1;

                    Console.Write(val1 + " + " + val2 + " = ");

                    string reponse = Console.ReadLine(); // on lit l'entr�e du joueur

                    /**
                     * Verification de l'entr�e du joueur
                     * Return true or false if entry is "int" or "not int"
                     */

                    int r = getNumber(reponse); // Renvoit l'entr�e du joueur en tant que int tant qu'il n'a pas entr� un int.

                    if ((val1 + val2) == r)
                    {
                        Console.WriteLine("Bonne r�ponse\n\n");
                        nbBonnesReponses = nbBonnesReponses + 1;
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise r�ponse\n\n");
                    }
                }
                else // sinon ==> multiplication
                {
                    Random rand2 = new Random(); // On cr�� les randoms des valeurs des calculs

                    const int min2 = 1;
                    const int max2 = 10;

                    int val1 = rand.Next(min2, max2 + 1);

                    int nombre1 = val1 + 1;

                    int val2 = rand.Next(min2, max2 + 1);

                    int nombre2 = val2 + 1;

                    Console.Write(val1 + " x " + val2 + " = ");
                    string reponse = Console.ReadLine(); // on lit l'entr�e du joueur

                    /**
                     * Verification de l'entr�e du joueur
                     * 
                     */

                    int r = getNumber(reponse); // Renvoit l'entr�e du joueur en tant que int tant qu'il n'a pas entr� un int.

                    if ((val1 * val2) == r)
                    {
                        Console.WriteLine("Bonne r�ponse\n\n");
                        nbBonnesReponses = nbBonnesReponses + 1;
                    }
                    else
                    {
                        Console.WriteLine("Mauvaise r�ponse\n\n");
                    }
                }

            }

            Console.WriteLine("Nombre de bonnes r�ponses : " + nbBonnesReponses + "/" + nbTotalQuestion);

            float a = (float)nbBonnesReponses; // Conversion en float
            float b = (float)nbTotalQuestion; // Conversion en float

            float pourcentageReussite = a / b; // calcul du winrate
            Console.WriteLine("Voici ton winrate : " + pourcentageReussite*100f + "%");

            if (pourcentageReussite == 0f)
                Console.WriteLine("T'as tout faux.");
            else if (pourcentageReussite == 1f)
                Console.WriteLine("C'est tout juste, bravo");
            else if (pourcentageReussite >= 0.25f && pourcentageReussite < 0.5f)
                Console.WriteLine("�a commence � rentrer.");
            else if (pourcentageReussite >= 0.5f && pourcentageReussite < 0.75f)
                Console.WriteLine("C'est bien.");
            else
                Console.WriteLine("C'est tr�s bien.");

        }

        /*
         * @description Fonction qui retourne l'entr�e du Console.Readline en tant que int apr�s v�rification
         * de la valeur de l'entr�e (redemande tant que entr�e diff�rent de int
         * @return int r = entr�e utilisateur
         */

        private static int getNumber(string entry)
        {
            bool state = int.TryParse(entry, out int r);

            while (state == false)
            {
                Console.Write("Valeur entr�e incorrecte, veuillez entrer un nombre entier : ");
                entry = Console.ReadLine();
                state = int.TryParse(entry, out r);
            }

            return r;
        }

        // Pareil que GetNumber mais pour nombre positif uniquement.

        private static int getNumberPositif(string entry)
        {
            bool state = int.TryParse(entry, out int q);
            bool positif = isPositiv(q);

            while (state == false || positif == false)
            {
                Console.Write("Valeur entr�e incorrecte, veuillez entrer un nombre entier POSITIF : ");
                entry = Console.ReadLine();
                state = int.TryParse(entry, out q);
                positif = isPositiv(q);
            }

            return q;
        }

        /*
         * @description V�rifie que le nombre est positif ou non
         * @return bool positif ou non
         */

        private static bool isPositiv(int number)
        {
            if (number > 0)
                return true;
            else
                return false;
        }

    }
}
