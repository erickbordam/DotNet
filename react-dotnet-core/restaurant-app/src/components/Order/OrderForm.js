import React from 'react'
import Form from '../../layouts/Form'
import { Grid } from '@mui/material'
import Input from '../../controls/Input'
import Select from '../../controls/Select'

export default function OrderForm() {
  return (
    <Form>
        <Grid container>
            <Grid item xs={6}>
                <Input disabled
                    name="orderNumber"
                    label="Order Number"
                 />
                 <Select label = "Customer"
                 name = "customerId"
                 options = {[
                    {id: '0', title: 'Select Customer'},
                    {id: '1', title: 'Customer 1'},
                    {id: '2', title: 'Customer 2'},
                    {id: '3', title: 'Customer 3'},
                    {id: '4', title: 'Customer 4'},
                 ]}/>
            </Grid>
            <Grid item xs={6}>
                <Input 
                    disabled
                    name="gTotal"
                    label="Grand Total"
                 />
            </Grid>
        </Grid>
    </Form>
  )
}
