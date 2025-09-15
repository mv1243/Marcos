using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez.Interface;

namespace Xadrez.Entity
{
    public class Rei : IPeca
    {
        public string Cor { get; set; }

        public string Nome { get; set; }
        public string Tipo { get; set; }
        public int[] Posicao { get; set; }
        public string Icone { get; set; }

        bool alguem_pode me comer = false;

       // public Rei(int cor, int pos_y, int pos_x)
       // Criar um for e retornar uma array de posiçoes[pos_y, pos_x]
       //
        public Rei(int cor)
        {
            Nome = "Rei";
           // Posicao = [pos_y, pos_x];
            if (cor == 1)
            {
                Cor = "Branco"; Icone = "♚";
            }
            if (cor == 2)
            {
                Cor = "Preto"; Icone = "♔";
            }
            Tipo = "Peça";
        }

        public bool PreMovimento(int y1, int x1, int y, int x, string tipo, string cor, IPeca[,] pecas)
        {
            //OBJETIVO RESCREVER A TABELA DENTRO DA FUNCAO

            ////Não Marcar a si mesmo
            if (y1 == y && x1 == x) return false;

            // Regras do Movimento
            if (DiagonalEsquerdaCima(y1, x1, y, x, pecas) || DiagonalDireitaCima(y1, x1, y, x, pecas)) return true;

            return false;


            static bool DiagonalEsquerdaCima(int y1, int x1, int y, int x, IPeca[,] pecas)
            {

                //TROCAR ORDEM DAS REGRAS
                int z = 1;
                //Aqui ele começa a mapear o tabuleiro começando pela peça que está sendo movida
                for (int i = (y1 - 1); i >= 0; i--)
                {
                    for (int j = (x1 - 1); j >= 0; j--)
                    {
                        if (pecas[i, j].Tipo == "Campo")
                        {
                            //após ele encontrar o campo selecionado, ele aplicará a regra da movimentação
                            if (pecas[i, j] == pecas[y, x])
                            {
                                //Diagonal Cima/Esquerda
                                if ((y1 - y) == z && (x1 - x) == z)
                                {

                                    return true;
                                }
                            }
                        }
                        // caso encontre uma peça, ele verificará se é do time adversário e aplicará a regra da movimentação
                        if (pecas[i, j].Tipo == "Peça")
                        {
                            if (pecas[y1, x1].Cor != pecas[i, j].Cor)
                            {
                                if (pecas[i, j] == pecas[y, x])
                                {
                                    //Diagonal Cima/Esquerda
                                    if ((y1 - y) == z && (x1 - x) == z)
                                    {

                                        return true;
                                    }
                                }
                            }
                            return false;
                        }
                    }
                    z++;
                }
                return false;
            }

            static bool DiagonalDireitaCima(int y1, int x1, int y, int x, IPeca[,] pecas)
            {
                int z = 1;
                int w = -1;
                //Aqui ele começa a mapear o tabuleiro começando pela peça que está sendo movida
                for (int i = (y1 - 1); i >= 0; i--)
                {
                    for (int j = (x1 - 1); j <= 7; j++)
                    {
                        if (pecas[i, j].Tipo == "Campo")
                        {
                            //após ele encontrar o campo selecionado, ele aplicará a regra da movimentação
                            if (pecas[i, j] == pecas[y, x])
                            {

                                //Diagonal Cima/Direita
                                if ((y1 - y) == z && (x1 - x) == w)
                                {
                                    return true;
                                }


                            }

                        }
                        // caso encontre uma peça, ele verificará se é do time adversário e aplicará a regra da movimentação
                        if (pecas[i, j].Tipo == "Peça")
                        {
                            if (pecas[y1, x1].Cor != pecas[i, j].Cor)
                            {
                                if (pecas[i, j] == pecas[y, x])
                                {

                                    //Diagonal Cima/Direita
                                    if ((y1 - y) == z && (x1 - x) == w)
                                    {
                                        return true;
                                    }

                                }
                            }
                            return false;
                        }
                    }
                    z++;
                    w--;
                }
                return false;
            }

            static bool DiagonalEsquerdaBaixo(int y1, int x1, int y, int x, IPeca[,] pecas)
            {
                int w = -1;
                int z = 1;
                //Aqui ele começa a mapear o tabuleiro começando pela peça que está sendo movida
                for (int i = (y1 - 1); i <= 7; i++)
                {
                    for (int j = (x1 - 1); j >= 0; j--)
                    {
                        if (pecas[i, j].Tipo == "Campo")
                        {
                            //após ele encontrar o campo selecionado, ele aplicará a regra da movimentação
                            if (pecas[i, j] == pecas[y, x])
                            {

                                //Diagonal Baixo/Esquerda
                                if ((y1 - y) == w && (x1 - x) == z)
                                {
                                    return true;
                                }


                            }

                        }
                        // caso encontre uma peça, ele verificará se é do time adversário e aplicará a regra da movimentação
                        if (pecas[i, j].Tipo == "Peça")
                        {
                            if (pecas[y1, x1].Cor != pecas[i, j].Cor)
                            {
                                if (pecas[i, j] == pecas[y, x])
                                {
                                    //Diagonal Baixo/Esquerda
                                    if ((y1 - y) == w && (x1 - x) == z)
                                    {
                                        return true;
                                    }


                                }
                            }
                            return false;
                        }
                    }
                    z++;
                    w--;
                }
                return false;
            }





            //if (tipo != "Peça") caminho_interrompido = true;

            //int i = 1;
            //int j = -1;
            //for (i = 1; i <= 8; i++, j--)
            //{


            //    if (caminho_interrompido)
            //    {

            //        //Diagonal Cima/Esquerda
            //        if ((y1 - y) == i && (x1 - x) == i)
            //        {
            //            return true;
            //        }

            //        //Diagonal Baixo/Direita
            //        if ((y1 - y) == j && (x1 - x) == j)
            //        {
            //            return true;
            //        }

            //        //Diagonal Cima/Direita
            //        if ((y1 - y) == i && (x1 - x) == j)
            //        {
            //            return true;
            //        }

            //        //Diagonal Baixo/Esquerda
            //        if ((y1 - y) == j && (x1 - x) == i)
            //        {
            //            return true;
            //        }
            //    }
            //}






            //Movimento do Rei
            //if ((y1- y) <= 1 && (y1 - y) >= -1 && (x1 - x) <= 1 && (x1 - x) >= -1 )
            //{
            //    return true;
            //}
            //return false;

            //Movimento da torre
            //if ((y1- y) < 1 && (y1 - y) > -1 || (x1 - x) < 1 && (x1 - x) > -1)
            //{
            //    return true;
            //}


        }
        public void MoverPeca()
        {

        }

    }
}
