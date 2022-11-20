using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game2048
{
    class Logic
    {

        
        Map map1 = new Map();


     
        private string[] drewsNums = new string[16];
        public string[] DrewsNums
        {
            get { return Drew(); }
            set { drewsNums = value; }
        }
        public string[] Drew()
        {
           
            map1.ShowStr = Map.Nums;

            string[] arr = new string[16];
            int box = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    arr[box] = map1.ShowStr[map1.Pos[i, j]];
                    box += 1;
                }
            }
            return arr;
        }

        public void Create ()
        {
            int i;
            int j;
            int num;
            Random ran = new Random();
            while (true)
            {
                i = ran.Next(0, 4);
                j = ran.Next(0, 4);
                num = ran.Next(1, 3);
                if (map1.Pos[i, j] == 0)
                {
                    map1.Pos[i, j] = num;

                    return;
                }
            }
        }

       
        public bool Lose()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map1.Pos[i, j]==0)
                    {
                        return false;
                    }
                    else
                    {
                        if (i == 0 && j == 0)
                        {
                            if (map1.Pos[i, j] == map1.Pos[i + 1, j] || map1.Pos[i, j] == map1.Pos[i, j + 1])
                            {
                                return false;
                            }
                        }
                        else if (i == 3 && j == 0)
                        {
                            if (map1.Pos[i, j] == map1.Pos[i - 1, j] || map1.Pos[i, j] == map1.Pos[i, j + 1])
                            {
                                return false;
                            }
                        }
                        else if (i == 0 && j == 3)
                        {
                            if (map1.Pos[i, j] == map1.Pos[i + 1, j] || map1.Pos[i, j] == map1.Pos[i, j - 1])
                            {
                                return false;
                            }
                        }
                        else if (i == 3 && j == 3)
                        {
                            if (map1.Pos[i, j] == map1.Pos[i - 1, j] || map1.Pos[i, j] == map1.Pos[i, j - 1])
                            {
                                return false;
                            }
                        }
                        else if (i!=0&&i!=3&&j!=0&&j!=3)
                        {
                            if (map1.Pos[i, j] == map1.Pos[i + 1, j] || map1.Pos[i, j] == map1.Pos[i - 1, j] || map1.Pos[i, j] == map1.Pos[i, j + 1] || map1.Pos[i, j] == map1.Pos[i, j - 1])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
       
        public void ReGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map1.Pos[i, j] = 0;
                }
            }
            Create();
        }

     
        public void RunLose()
        {
            if (Lose())
            {
                DialogResult dr = MessageBox.Show("Вы проиграли", "Игра окончена", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    ReGame();
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (map1.Pos[i, j] == 11)
                        {
                            MessageBox.Show("Заново");
                        }
                    }
                }
            }
        }
       
        public bool CanUp()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ( (map1.Pos[i, j] != 0 &&  map1.Pos[i-1, j] == 0) || (map1.Pos[i, j] != 0 && map1.Pos[i, j] == map1.Pos[i-1, j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
      
        public bool CanLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if ((map1.Pos[i, j] != 0 && map1.Pos[i, j-1] == 0) || (map1.Pos[i, j] != 0 && map1.Pos[i, j] == map1.Pos[i, j-1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        public bool CanRight()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((map1.Pos[i, j] != 0 && map1.Pos[i, j + 1] == 0) || (map1.Pos[i, j] != 0 && map1.Pos[i, j] == map1.Pos[i, j + 1]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
      
        public bool CanDown()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((map1.Pos[i, j] != 0 && map1.Pos[i+1, j] == 0) || (map1.Pos[i, j] != 0 && map1.Pos[i, j] == map1.Pos[i+1,j]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        
        public void Up()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map1.Pos[i, j]!=0)
                    {
                        for (int k = i + 1; k < 4; k++)
                        {
                            if (map1.Pos[k, j] != 0)
                            {
                                if (map1.Pos[i, j] == map1.Pos[k, j])
                                {
                                    map1.Pos[i, j] += 1;
                                    map1.Pos[k, j] = 0;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        for (int k = i + 1; k < 4; k++)
                        {
                            if (map1.Pos[k, j] != 0)
                            {
                                if (map1.Pos[i, j] == 0)
                                {
                                    map1.Pos[i, j] = map1.Pos[k, j];
                                    map1.Pos[k, j] = 0;
                                }
                                for (int l = k+1; l < 4; l++)
                                {
                                    if (map1.Pos[l, j] != 0)
                                    {
                                        if (map1.Pos[i, j] == map1.Pos[l, j])
                                        {
                                            map1.Pos[i, j] += 1;
                                            map1.Pos[l, j] = 0;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        
        public void Left()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (map1.Pos[i, j] != 0)
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (map1.Pos[i, k] != 0)
                            {
                                if (map1.Pos[i, j] == map1.Pos[i, k])
                                {
                                    map1.Pos[i, j] += 1;
                                    map1.Pos[i, k] = 0;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        for (int k = j + 1; k < 4; k++)
                        {
                            if (map1.Pos[i, k] != 0)
                            {
                                if (map1.Pos[i, j] ==0)
                                {
                                    map1.Pos[i, j] = map1.Pos[i, k];
                                    map1.Pos[i, k] = 0;
                                }
                                
                                for (int l = k + 1; l < 4; l++)
                                {
                                    if (map1.Pos[i, l] != 0)
                                    {
                                        if (map1.Pos[i, j] == map1.Pos[i, l])
                                        {
                                            map1.Pos[i, j] += 1;
                                            map1.Pos[i, l] = 0;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        
        public void Right()
        {
            for (int j = 3; j > 0; j--)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (map1.Pos[i, j] != 0)
                    {
                        for (int k = j - 1; k >=0; k--)
                        {
                            if (map1.Pos[i, k] != 0)
                            {
                                if (map1.Pos[i, j] == map1.Pos[i, k])
                                {
                                    map1.Pos[i, j] += 1;
                                    map1.Pos[i, k] = 0;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        for (int k = j - 1; k >= 0; k--)
                        {
                            if (map1.Pos[i, k] != 0)
                            {
                                if (map1.Pos[i, j] == 0)
                                {
                                    map1.Pos[i, j] = map1.Pos[i, k];
                                    map1.Pos[i, k] = 0;
                                }
                                
                                for (int l = k - 1; l >= 0; l--)
                                {
                                    if (map1.Pos[i, l] != 0)
                                    {
                                        if (map1.Pos[i, j] == map1.Pos[i, l])
                                        {
                                            map1.Pos[i, j] += 1;
                                            map1.Pos[i, l] = 0;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
       
        public void Down()
        {
            for (int i = 3; i >0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (map1.Pos[i, j] != 0)
                    {
                        for (int k = i - 1; k >=0; k--)
                        {
                            if (map1.Pos[k, j] != 0)
                            {
                                if (map1.Pos[i, j] == map1.Pos[k, j])
                                {
                                    map1.Pos[i, j] += 1;
                                    map1.Pos[k, j] = 0;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                    }
                    else
                    {
                        for (int k = i - 1; k >=0; k--)
                        {
                            if (map1.Pos[k, j] != 0)
                            {
                                if (map1.Pos[i, j] == 0)
                                {
                                    map1.Pos[i, j] = map1.Pos[k, j];
                                    map1.Pos[k, j] = 0;
                                }
                                
                                for (int l = k - 1; l >=0; l--)
                                {
                                    if (map1.Pos[l, j] != 0)
                                    {
                                        if (map1.Pos[i, j] == map1.Pos[l, j])
                                        {
                                            map1.Pos[i, j] += 1;
                                            map1.Pos[l, j] = 0;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
